async function validationGridFill() {
    //console.log('<div class="template-areas-cell11"></div>');
    let div = document.createElement('div');
    div.className = "alert";
    div.innerHTML = "<strong>1</strong>";
    await document.getElementById('validationGridFill').append(div);
    await console.log(document.getElementsByClassName('alert')[0])
    await document.getElementsByClassName('alert')[0].insertAdjacentHTML('afterend', '<div class="bla">2</div>');
    await document.getElementsByClassName('bla')[0].insertAdjacentHTML('afterend', '<div class="bla2">3</div>');
    await document.getElementsByClassName('bla2')[0].insertAdjacentHTML('afterend', '<div class="bla3">4</div>');

    //append(document.createElement('div'));
    //await .innerHTML = 'asd'
    await document.getElementById('validationGridFill').append(div);
}