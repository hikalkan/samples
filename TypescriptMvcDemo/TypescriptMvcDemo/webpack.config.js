const path = require('path');

module.exports = {
    entry: './wwwroot/app/Pages/Index.ts',
    mode: 'development',
    module: {
        rules: [
            {
                test: /\.tsx?$/,
                use: 'ts-loader',
                exclude: /node_modules/
            }
        ]
    },
    resolve: {
        extensions: ['.tsx', '.ts', '.js']
    },
    output: {
        path: path.resolve(__dirname, 'wwwroot/app/Pages'),
        filename: 'Index.Bundle.js'
    }
};