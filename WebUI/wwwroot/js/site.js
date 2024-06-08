﻿document.addEventListener('DOMContentLoaded', function () {
    const zoomableImages = document.querySelectorAll('.zoomable-image');

    zoomableImages.forEach(image => {
        image.addEventListener('click', function () {
            const imageUrl = image.getAttribute('src');
            const zoomedImage = document.createElement('img');
            zoomedImage.setAttribute('src', imageUrl);
            zoomedImage.classList.add('zoomed-image');

            const overlay = document.createElement('div');
            overlay.classList.add('overlay');
            overlay.appendChild(zoomedImage);

            document.body.appendChild(overlay);
        });
    });

    document.addEventListener('click', function (event) {
        if (event.target.classList.contains('overlay')) {
            event.target.remove();
        }
    });
});

document.addEventListener('DOMContentLoaded', function () {
    $('.owl-carousel').owlCarousel({
        loop: true,
        nav: true,
        navText: ["<i class='fas fa-chevron-left'></i>", "<i class='fas fa-chevron-right'></i>"],
        responsive: {
            0: {
                items: 2,
                nav: false
            },
            600: {
                items: 3,
                nav: false
            },
            1000: {
                items: 4.2
            }
        }
    });
});

