import { Controller } from "@hotwired/stimulus"

export default class extends Controller {

  connect() {
    this.sayHi('foo');
  }

  sayHi(controllerName) {
    console.log(`Hello from the '${controllerName}' controller.`, this.element);
  }
}
