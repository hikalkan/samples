export class PersonDto {
    constructor(public name: string) {
        $('.content').append('<p>' + name + '</p>');
    }
}