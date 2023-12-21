import '../css/style.css'

import * as Turbo from '@hotwired/turbo'
Turbo.session.drive = true

import './signalRTurboStreamElement'

import { Application } from "@hotwired/stimulus"
const application = Application.start();
window.Stimulus = application
const controllers = import.meta.glob('./**/*_controller.js')

Object.entries(controllers).forEach((obj, idx) => {
  const path = obj[0]
  const controllerName = path.substring('./controllers/'.length, path.length - '_controller.js'.length)

  import(path)
    .then(controller => {
      application.register(controllerName, controller.default)
    })
  
});
