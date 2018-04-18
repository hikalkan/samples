import { PersonDto } from "../Dtos/PersonDto";
var Index = /** @class */ (function () {
    function Index() {
    }
    Index.prototype.init = function () {
        var john = new PersonDto("john");
        var david = new PersonDto("david");
        console.log('initialized Pages.Index');
        console.log(john.name);
        console.log(david.name);
    };
    return Index;
}());
export { Index };
new Index().init();
//# sourceMappingURL=Index.js.map