const mongoose = require('mongoose');
const {database} = require('./keys')

//realiza la conexion a mongodb
mongoose.connect(database.URI, {useNewUrlParser:true})
    .then(db => console.log('DB esta conectada'))
    .catch(err => console.error(err));