import { PersonDto } from "../Dtos/PersonDto";

namespace Pages {
    export class Index {
        init(): void {
            var john = new PersonDto("john");
            var david = new PersonDto("david");

            console.log('initialized Pages.Index');

            console.log(john.name);
            console.log(david.name);
        }
    }
}
new Pages.Index().init();

//declare let window: any;
//window.xxxx = 5;