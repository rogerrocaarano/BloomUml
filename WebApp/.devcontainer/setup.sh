#!/bin/bash
rm -rf /workspace/WebApp/.angular
rm -rf /workspace/WebApp/node_modules
rm -rf /workspace/WebApp/dist

npm install --prefix /workspace/WebApp
npx npx syncfusion-license activate --prefix /workspace/WebApp