document.getElementById('form1').addEventListener('input', function () {
    var searchButton = document.getElementById('search-button');
    if (this.value.trim() !== '') {
        searchButton.classList.add('btn-yellow-border');
    } else {
        searchButton.classList.remove('btn-yellow-border');
    }
});

var slideIndex = 0;
var images = document.querySelectorAll(".slideshow-image");
var blogBoxImages = document.querySelector(".blog-box1").querySelectorAll("img");

function showSlides() {
    for (var i = 0; i < images.length; i++) {
        images[i].classList.remove("active");
    }

    slideIndex++;
    if (slideIndex > images.length) {
        slideIndex = 1;
    }

    images[slideIndex - 1].classList.add("active");

    for (var i = 0; i < blogBoxImages.length; i++) {
        blogBoxImages[i].classList.remove("active");
    }

    blogBoxImages[slideIndex - 1].classList.add("active");

    setTimeout(showSlides, 3000); // Change slide every 3 seconds
}

showSlides();


var employedSelect = document.getElementById("employed");
var employmentDetails = document.querySelector(".employment-details");
var submitButton = document.querySelector(".submit-button");

employedSelect.addEventListener("change", function () {
    if (employedSelect.value === "Yes") {
        employmentDetails.style.display = "block";
    } else {
        employmentDetails.style.display = "none";
    }
});



function toggleFormContainer() {
    var formContainer = document.getElementById("formContainer");
    if (formContainer.style.display === "none") {
        formContainer.style.display = "block";
    } else {
        formContainer.style.display = "none";
    }
}
