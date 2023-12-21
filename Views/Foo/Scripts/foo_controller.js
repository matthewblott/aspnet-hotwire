import { Controller } from "/dist/node_modules/.vite/deps/@hotwired_stimulus.js"

export default class FooController extends Controller {

  connect() {
    this.sayHi('foo');
  }

  sayHi(controllerName) {
    console.log(`Hello from the '${controllerName}' controller.`, this.element);
  }
}
