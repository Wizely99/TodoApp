/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./**/*.{razor,html,cshtml}"],
  theme: {
    extend: {
      colors: {
       'primary': {
        '50': '#ecfffe',
        '100': '#cefffe',
        '200': '#a3fefe',
        '300': '#64fafc',
        '400': '#1decf3',
        '500': '#01ced9',
        '600': '#04a5b6',
        '700': '#0b8494',
        '800': '#136977',
        '900': '#145765',
        '950': '#073a45',
    },
    
      },
    },
  },
  plugins: [],
};
