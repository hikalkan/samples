const path = require('path');

module.exports = {
    entry: './wwwroot/app/Pages/Index.js',
    mode: 'development',
    output: {
        path: path.resolve(__dirname, 'wwwroot/app/Pages'),
        filename: 'Index.Bundle.js'
    }
};