//Archivo de arranque de la app
//configuracion del servidor
const express = require('express');
const config = require('./server/config');
//conexion a la base de datos
require('./database');//Solamente con requerirlo lo ejecuta
//Se crea esta variable para que quede mas prolijo, tiene acceso a config.js del servidor
const app = config(express());


app.listen(app.get('port'), ()=>{
    console.log('server on port:',app.get('port'));
})
