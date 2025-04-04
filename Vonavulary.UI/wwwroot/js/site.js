document.addEventListener("DOMContentLoaded", function () {
    const navbarToggle = document.getElementById("navbar-toggle");
    const navbarMenuContainer = document.getElementById("navbar-menu-container");
    const body = document.body;

    navbarToggle.addEventListener("click", function () {
        navbarToggle.classList.toggle("active");
        navbarMenuContainer.classList.toggle("active");
        body.classList.toggle("menu-open");
    });

    // Close menu when clicking on a link
    const navLinks = document.querySelectorAll(".navbar-link");
    navLinks.forEach(link => {
        link.addEventListener("click", function() {
            navbarToggle.classList.remove("active");
            navbarMenuContainer.classList.remove("active");
            body.classList.remove("menu-open");
        });
    });

    // Close menu when ESC key is pressed
    document.addEventListener("keydown", function(event) {
        if (event.key === "Escape" && navbarMenuContainer.classList.contains("active")) {
            navbarToggle.classList.remove("active");
            navbarMenuContainer.classList.remove("active");
            body.classList.remove("menu-open");
        }
    });

    // Adjust for window resize
    window.addEventListener("resize", function() {
        if (window.innerWidth > 768 && navbarMenuContainer.classList.contains("active")) {
            navbarToggle.classList.remove("active");
            navbarMenuContainer.classList.remove("active");
            body.classList.remove("menu-open");
        }
    });
});