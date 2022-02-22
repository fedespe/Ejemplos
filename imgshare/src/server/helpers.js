//Archivo de helpers pero para handlebars
const moment = require('moment');
const { model } = require('../models/image');
const helpers={};

//Creo una funcion para calcular el tiempo en el cual se creo la publicacion
helpers.timeAgo=timestamp=>{
    return moment(timestamp).startOf('minute').fromNow();
}

module.exports=helpers;