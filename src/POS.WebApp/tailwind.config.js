/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ['./**/*.{razor,html}'],
  theme: {
    extend: {
      colors: {
        // text color
        '--text-primary': '',
        '--text-secondary': '',
        '--text-success': '',
        '--text-danger': '',
        '--text-warning': '',
        '--text-info': '',
        '--text-dark': '',
        '--text-light': '',
        '--grey': '#DBDBDB',
        // backgrond color
        'bg-primary': '#111315',
        'bg-secondary': '',
        'bg-success': '',
        'bg-danger': '',
        'bg-warning': '',
        'bg-info': '',

        'link-primary': '',
        '--blue': '#1fb6ff',
        '--purple': '#7e5bef',
        '--pink': '#ff49db',
        '--orange': '#ff7849',
        '-green': '#13ce66',
        '--yellow': '#ffc82c',
        '--gray-dark': '#273444',
        '--gray': '#8492a6',
        '--gray-light': '#d3dce6',
        '--black': '#121315',
        '--dkblue': '#0d314b',
        '--plum': '#4b0d49',
        '--hotmag': '#ff17e4',
        '--magenta': '#e310cb',
        '--aqua': '#86fbfb',
        '--white': '#f7f8fa',
        '--bg-black': '#111315',
        '--bg-white': '#f7f8fa',
        '--bg-black2': '#2d2d2d',
        '--bg-green': '#cfdddb',
      },
      fontFamily: {
        'sans': ['ui-sans-serif', 'system-ui'],
        'serif': ['ui-serif', 'Georgia'],
        'mono': ['ui-monospace', 'SFMono-Regular'],
        'display': ['Oswald'],
        'body': ['"Open Sans"'],
      }
    },
  },
  plugins: [],
}

