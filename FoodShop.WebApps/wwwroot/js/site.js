function setTheme(mode) {
    document.documentElement.setAttribute('data-theme', mode);
    localStorage.setItem('theme', mode);

    // UPDATE CHARTS THEME
    if (window.chartHelper?.charts) {
        Object.values(window.chartHelper.charts).forEach(chart => {
            window.chartHelper.applyTheme(chart.config);
            chart.update();
        });
    }
}

async function loadTheme() {
    const current_mode = await localStorage.getItem('theme') ?? 'light';

    document.documentElement.setAttribute('data-theme', current_mode);

    return current_mode;
}
