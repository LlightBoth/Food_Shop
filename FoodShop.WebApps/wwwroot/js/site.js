function setTheme(mode) {
    document.documentElement.setAttribute('data-theme', mode);
    localStorage.setItem('theme', mode);

    // UPDATE CHARTS THEME
    Object.values(window.chartHelper.charts).forEach(chart => {
        window.chartHelper.applyTheme(chart.config);
        chart.update();
    });
}
