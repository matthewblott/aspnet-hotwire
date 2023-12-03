import 'vite/modulepreload-polyfill';
import './style.css'

import * as Turbo from '@hotwired/turbo'

Turbo.session.drive = true 

document.addEventListener('turbo:load', function (e) {
  console.log('turbo:load', e);
});

document.addEventListener('turbo:visit', function (e) {
  console.log('turbo:visit', e);
});

document.addEventListener('turbo:frame-load', function (e) {
  console.log('turbo:frame-load', e);
});
