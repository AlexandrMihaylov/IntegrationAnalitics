async function validationGridFill() {
    let bi_check2_circle = "<svg xmlns=\"http://www.w3.org/2000/svg\" color=\"green\" width=\"24\" height=\"24\" fill=\"currentColor\" class=\"bi bi-check2-circle\" viewBox=\"0 0 16 16\">+\n" +
        "<path d=\"M2.5 8a5.5 5.5 0 0 1 8.25-4.764.5.5 0 0 0 .5-.866A6.5 6.5 0 1 0 14.5 8a.5.5 0 0 0-1 0 5.5 5.5 0 1 1-11 0z\"/>+\n" +
        "<path d=\"M15.354 3.354a.5.5 0 0 0-.708-.708L8 9.293 5.354 6.646a.5.5 0 1 0-.708.708l3 3a.5.5 0 0 0 .708 0l7-7z\"/>+\n" +
        "</svg>";
    let bi_backspace = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"24\" color=\"red\" fill=\"currentColor\" class=\"bi bi-backspace\" classNameox=\"0 0 16 16\">+\n" +
        "<path d=\"M5.83 5.146a.5.5 0 0 0 0 .708L7.975 8l-2.147 2.146a.5.5 0 0 0 .707.708l2.147-2.147 2.146 2.147a.5.5 0 0 0 .707-.708L9.39 8l2.146-2.146a.5.5 0 0 0-.707-.708L8.683 7.293 6.536 5.146a.5.5 0 0 0-.707 0z\"/>+\n" +
        "<path d=\"M13.683 1a2 2 0 0 1 2 2v10a2 2 0 0 1-2 2h-7.08a2 2 0 0 1-1.519-.698L.241 8.65a1 1 0 0 1 0-1.302L5.084 1.7A2 2 0 0 1 6.603 1h7.08zm-7.08 1a1 1 0 0 0-.76.35L1 8l4.844 5.65a1 1 0 0 0 .759.35h7.08a1 1 0 0 0 1-1V3a1 1 0 0 0-1-1h-7.08z\"/>+\n" +
        "</svg>";
    let bi_info_circleclassNamewBox = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"24\" color=\"blue\" fill=\"currentColor\" class=\"bi bi-info-circleclassNamewBox=\"0 0 16 16\">" +
        "<path d = \"M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14zm0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16z\"/>+\n" +
        "<path d = \"m8.93 6.588-2.29.287-.082.38.45.083c.294.07.352.176.288.469l-.738 3.468c-.194.897.105 1.319.808 1.319.545 0 1.178-.252 1.465-.598l.088-.416c-.2.176-.492.246-.686.246-.275 0-.375-.193-.304-.533L8.93 6.588zM9 4.5a1 1 0 1 1-2 0 1 1 0 0 1 2 0z\"/>+\n" +
        "</svg>";

    let row = ["1. agreement.xsd - agreement.xml","15:06 21.12.2022","15:06 21.12.2022",bi_check2_circle,bi_check2_circle];

    for (let i = 0; i <= 49; i++) {
        if (i===15){
            row[3] = bi_backspace;
            row[4] = bi_info_circleclassNamewBox;
            for(let n = 0; n <= 4; n++){
                await document.getElementsByClassName('panel-scroll-grid')[0].insertAdjacentHTML('beforeend', '<div class="cell">'+row[n]+'</div>');
            }
            row[3] = bi_check2_circle;
            row[4] = bi_check2_circle;
        }
        else{
            for(let n = 0; n <= 4; n++){
                await document.getElementsByClassName('panel-scroll-grid')[0].insertAdjacentHTML('beforeend', '<div class="cell">'+row[n]+'</div>');
            }
        }
    }
}