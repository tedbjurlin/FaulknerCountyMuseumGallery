


const handelImageLoad = () => {
    gallery.classList.remove('is-loading');
    image.removeEventListener('load',handelImageLoad)
}

// {/* <img class=\"M_logo_key_img\" src=\"~/Falkner_county_logo_key.png\"> */}
const loader = "<div class=\"loader\"><div></div>";
const image = document.getElementsByClassName('gallery_image');
const imagel = image;
if(!image.complete) {
    for(var i = 0; i < image.length; i++) {
        image[i].addEventListener('load', handelImageLoad);
        image[i].outerHTML = loader;
    }
}
else {
    for(var i = 0; i < image.length; i++) { 
        image[i].removeEventListener('load', handelImageLoad);
        image[i].replaceWith(imagel[i]);
    }
}



