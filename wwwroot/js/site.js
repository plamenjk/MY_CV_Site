document.addEventListener("DOMContentLoaded", () => {
    const body = document.querySelector("body");
    const glow = document.querySelector(".global-glow");
    const themeToggle = document.getElementById("themeToggle");

    // Прилага тема визуално
    function applyTheme(theme) {
        if (theme === "light") {
            body.classList.remove("theme-dark");
            body.classList.add("theme-light");

            if (glow) {
                glow.classList.remove("glow-dark");
                glow.classList.add("glow-light");
            }

        } else {
            body.classList.remove("theme-light");
            body.classList.add("theme-dark");

            if (glow) {
                glow.classList.remove("glow-light");
                glow.classList.add("glow-dark");
            }
        }
    }

    // Зареждаме запазената тема
    const savedTheme = localStorage.getItem("theme") || "dark";
    applyTheme(savedTheme);

    // При клик → сменя тема + твърд refresh
    if (themeToggle) {
        themeToggle.addEventListener("click", () => {
            const newTheme = body.classList.contains("theme-light") ? "dark" : "light";

            // Записваме в localStorage
            localStorage.setItem("theme", newTheme);

            // Прилагаме веднага за визуален ефект
            applyTheme(newTheme);

            // И след 150ms → ТВЪРД ПРЕЗАРЕЖДАНЕ
            setTimeout(() => {
                window.location.reload(true);
            }, 150);
        });
    }
});
