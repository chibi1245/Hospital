document.addEventListener("DOMContentLoaded", function () {
    const themeToggle = document.getElementById("themeToggle");
    const body = document.body;

    // Load saved theme from localStorage
    if (localStorage.getItem("theme") === "dark") {
        enableDarkTheme();
    }

    // Toggle theme on button click
    themeToggle.addEventListener("click", function () {
        if (body.classList.contains("dark-theme")) {
            disableDarkTheme();
        } else {
            enableDarkTheme();
        }
    });

    function enableDarkTheme() {
        body.classList.add("dark-theme");
        localStorage.setItem("theme", "dark");
        themeToggle.textContent = "Light Mode";
    }

    function disableDarkTheme() {
        body.classList.remove("dark-theme");
        localStorage.setItem("theme", "light");
        themeToggle.textContent = "Dark Mode";
    }

    // Table row highlight on click
    document.querySelectorAll(".table tbody tr").forEach(row => {
        row.addEventListener("click", function () {
            document.querySelectorAll(".table tbody tr").forEach(r => r.classList.remove("selected"));
            this.classList.add("selected");
        });
    });

    // Smooth scrolling for anchor links
    document.querySelectorAll('a[href^="#"]').forEach(anchor => {
        anchor.addEventListener("click", function (e) {
            e.preventDefault();
            const targetId = this.getAttribute("href").substring(1);
            const targetElement = document.getElementById(targetId);
            if (targetElement) {
                window.scrollTo({
                    top: targetElement.offsetTop - 50,
                    behavior: "smooth"
                });
            }
        });
    });
});
