/** @type {import('tailwindcss').Config} */
module.exports = {
    content: ["./src/**/*.{html,ts,scss}"],
    important: true,
    theme: {
        extend: {
            colors: {
                primary: "var(--sys-primary)",
                "surface-tint": "var(--sys-surface-tint)",
                "on-primary": "var(--sys-on-primary)",
                "primary-container": "var(--sys-primary-container)",
                "on-primary-container": "var(--sys-on-primary-container)",
                secondary: "var(--sys-secondary)",
                "on-secondary": "var(--sys-on-secondary)",
                "secondary-container": "var(--sys-secondary-container)",
                "on-secondary-container": "var(--sys-on-secondary-container)",
                tertiary: "var(--sys-tertiary)",
                "on-tertiary": "var(--sys-on-tertiary)",
                "tertiary-container": "var(--sys-tertiary-container)",
                "on-tertiary-container": "var(--sys-on-tertiary-container)",
                error: "var(--sys-error)",
                "on-error": "var(--sys-on-error)",
                "error-container": "var(--sys-error-container)",
                "on-error-container": "var(--sys-on-error-container)",
                background: "var(--sys-background)",
                "on-background": "var(--sys-on-background)",
                surface: "var(--sys-surface)",
                "on-surface": "var(--sys-on-surface)",
                "surface-variant": "var(--sys-surface-variant)",
                "on-surface-variant": "var(--sys-on-surface-variant)",
                outline: "var(--sys-outline)",
                "outline-variant": "var(--sys-outline-variant)",
                shadow: "var(--sys-shadow)",
                scrim: "var(--sys-scrim)",
                "inverse-surface": "var(--sys-inverse-surface)",
                "inverse-on-surface": "var(--sys-inverse-on-surface)",
                "inverse-primary": "var(--sys-inverse-primary)",
                "primary-fixed": "var(--sys-primary-fixed)",
                "on-primary-fixed": "var(--sys-on-primary-fixed)",
                "primary-fixed-dim": "var(--sys-primary-fixed-dim)",
                "on-primary-fixed-variant":
                    "var(--sys-on-primary-fixed-variant)",
                "secondary-fixed": "var(--sys-secondary-fixed)",
                "on-secondary-fixed": "var(--sys-on-secondary-fixed)",
                "secondary-fixed-dim": "var(--sys-secondary-fixed-dim)",
                "on-secondary-fixed-variant":
                    "var(--sys-on-secondary-fixed-variant)",
                "tertiary-fixed": "var(--sys-tertiary-fixed)",
                "on-tertiary-fixed": "var(--sys-on-tertiary-fixed)",
                "tertiary-fixed-dim": "var(--sys-tertiary-fixed-dim)",
                "on-tertiary-fixed-variant":
                    "var(--sys-on-tertiary-fixed-variant)",
                "surface-dim": "var(--sys-surface-dim)",
                "surface-bright": "var(--sys-surface-bright)",
                "surface-container-lowest":
                    "var(--sys-surface-container-lowest)",
                "surface-container-low": "var(--sys-surface-container-low)",
                "surface-container": "var(--sys-surface-container)",
                "surface-container-high": "var(--sys-surface-container-high)",
                "surface-container-highest":
                    "var(--sys-surface-container-highest)"
            }
        }
    },
    plugins: []
};
