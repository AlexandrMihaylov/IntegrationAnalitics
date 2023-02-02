async function validationGridFill() {
    let check2_circle = "<svg xmlns=\"http://www.w3.org/2000/svg\" color=\"green\" width=\"24\" height=\"24\" fill=\"currentColor\" class=\"bi bi-check2-circle\" viewBox=\"0 0 16 16\">+\n" +
        "<path d=\"M2.5 8a5.5 5.5 0 0 1 8.25-4.764.5.5 0 0 0 .5-.866A6.5 6.5 0 1 0 14.5 8a.5.5 0 0 0-1 0 5.5 5.5 0 1 1-11 0z\"/>+\n" +
        "<path d=\"M15.354 3.354a.5.5 0 0 0-.708-.708L8 9.293 5.354 6.646a.5.5 0 1 0-.708.708l3 3a.5.5 0 0 0 .708 0l7-7z\"/>+\n" +
        "</svg>";

    let row = ["1. agreement.xsd - agreement.xml","15:06 21.12.2022","15:06 21.12.2022",check2_circle,check2_circle];

    for (let i = 0; i <= 49; i++) {
        for(let n = 0; n <= 4; n++){
            await document.getElementsByClassName('panel-scroll-grid')[0].insertAdjacentHTML('beforeend', '<div class="cell">'+row[n]+'</div>');
        }
    }
}