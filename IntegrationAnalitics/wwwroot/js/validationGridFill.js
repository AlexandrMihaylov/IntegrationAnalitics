async function validationGridFill() {
    //console.log('<div class="template-areas-cell11"></div>');
    let div = document.createElement('div');
    div.className = "alert";
    div.innerHTML = "<strong>Ы</strong>";
    await document.getElementById('validationGridFill').append(div);
    await console.log(document.getElementsByClassName('alert')[0])
    await document.getElementsByClassName('alert')[0].insertAdjacentHTML('afterend', '<div class="bla">Пока</div>');
    await document.getElementsByClassName('bla')[0].insertAdjacentHTML('afterend', '<div class="bla2">Привет</div>');

    //append(document.createElement('div'));
    //await .innerHTML = 'asd'
    await document.getElementById('validationGridFill').append(div);
}