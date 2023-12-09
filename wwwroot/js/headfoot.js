


var start, end;


var c = document.getElementsByClassName('circle');
for(var i = 0; i < c.length; i++) {
    c[i].addEventListener ("mouseover", Min);
    c[i].addEventListener ("mouseout", Mout);
}


function begin() {
    start = new Date();
}

function finish() {
    end = new Date();
    end = (end-start)/1000;
    if(end > 1) {
        end = 1;
    }
}


function Min(event) {
    begin();
    event.target.style.animation = 'circle 1s';
    event.target.style.backgroundImage = 'radial-gradient(circle 44px,rgb(115, 187, 84, 1), rgb(132, 205, 101, 1))';
}

function Mout(event) {
    finish();
    var reverse_circle = '@keyframes reverse_circle { 0% {background-image: radial-gradient(circle 4px, rgb(115, 187, 84, ' + end * + '1), rgb(132, 205, 101, ' + end * + '1));}10% {background-image: radial-gradient(circle 8px, rgb(115, 187, 84, ' + end * + '0.9), rgb(132, 205, 101, ' + end * + '0.9));}20% {background-image: radial-gradient(circle 12px, rgb(115, 187, 84, ' + end * + '0.8), rgb(132, 205, 101, ' + end * + '0.8)); }30% {background-image: radial-gradient(circle 16px, rgb(115, 187, 84, ' + end * + '0.7), rgb(132, 205, 101, ' + end * + '0.7));}40% { background-image: radial-gradient(circle 20px, rgb(115, 187, 84, ' + end * + '0.6), rgb(132, 205, 101, ' + end * + '0.6));}50% {  background-image: radial-gradient(circle 24px, rgb(115, 187, 84, ' + end * + '0.5), rgb(132, 205, 101, ' + end * + '0.5));}60% {background-image: radial-gradient(circle 28px, rgb(115, 187, 84, ' + end * + '0.4), rgb(132, 205, 101,' + end * + '0.4));}70% {  background-image: radial-gradient(circle 32px, rgb(115, 187, 84, ' + end * + '0.3), rgb(132, 205, 101, ' + end * + '0.3));}80% {background-image: radial-gradient(circle 36px, rgb(115, 187, 84, ' + end * + '0.2), rgb(132, 205, 101, ' + end * + '0.2));}90% {background-image: radial-gradient(circle 40px, rgb(115, 187, 84, ' + end * + '0.1), rgb(132, 205, 101, ' + end * + '0.1));}100% {background-image: radial-gradient(circle 44px,rgb(115, 187, 84, 0), rgb(132, 205, 101, 0));}}'
    event.target.style.animation = 'reverse_circle '+ end * 1+ 's';
    event.target.style.backgroundImage = 'radial-gradient(circle 44px,rgb(115, 187, 84, 1), rgb(115, 187, 84, 1))';
}