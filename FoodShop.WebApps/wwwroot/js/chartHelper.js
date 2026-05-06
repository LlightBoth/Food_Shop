window.chartHelper = {
    charts: {},

    createOrUpdateChart: function (id, config) {
        const canvas = document.getElementById(id);

        if (!canvas) {
            console.error("Canvas not found:", id);
            return;
        }

        const ctx = canvas.getContext("2d");

        // ✅ Apply theme BEFORE rendering
        this.applyTheme(config);

        if (this.charts[id]) {
            this.charts[id].destroy();
        }

        this.charts[id] = new Chart(ctx, config);
    },

   applyTheme: function (config) {
    // Use --current-text for all text in chart
    const textColor = getCSSVar('--current-text');
    const gridColor = getCSSVar('--chart-grid-color');

    if (!config.options) config.options = {};
    if (!config.options.plugins) config.options.plugins = {};
    if (!config.options.plugins.legend) config.options.plugins.legend = {};
    if (!config.options.plugins.legend.labels) config.options.plugins.legend.labels = {};

    config.options.plugins.legend.labels.color = textColor;

    if (!config.options.scales) config.options.scales = {};

    ['x', 'y'].forEach(axis => {
        if (!config.options.scales[axis]) config.options.scales[axis] = {};

        config.options.scales[axis].ticks = {
            ...(config.options.scales[axis].ticks || {}),
            color: textColor
        };

        config.options.scales[axis].grid = {
            ...(config.options.scales[axis].grid || {}),
            color: gridColor
        };
    });

    // Apply dataset colors if missing
    if (config.data && config.data.datasets) {
        const colors = [
            getCSSVar('--chart-color-1'),
            getCSSVar('--chart-color-2'),
            getCSSVar('--chart-color-3'),
            getCSSVar('--chart-color-4'),
            getCSSVar('--chart-color-5')
        ];

        config.data.datasets.forEach((ds, i) => {
            if (!ds.backgroundColor) {
                ds.backgroundColor = colors[i % colors.length];
            }
            // Optionally also set borderColor to match current text
            if (!ds.borderColor) {
                ds.borderColor = textColor;
            }
        });
    }
}
};

function getCSSVar(name) {
    return getComputedStyle(document.documentElement)
        .getPropertyValue(name)
        .trim();
}