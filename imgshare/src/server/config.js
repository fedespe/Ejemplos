const path = require('path');
const exphbs = require('express-handlebars');
const morgan = require('morgan');//en algunos lugares le llaman logger
const multer = require('multer');
const errorHandler = require('errorhandler');
const express = require('express');
const routes = require('../routes/index');



//configuracion del servidor
module.exports = app => {
    //SETTINGS

    //Establesco puerto del servidor
    app.set('port', process.env.PORT || 3000); //si existe un puerto en el sistema se utiliza, sino usa el 3000 
    //le digo a node donde van a estar las vistas
    app.set('views',path.join(__dirname, '../views'));
    
    //motor de plantillas hbs=handlebars
    var hbs = exphbs.create({ 
        defaultLayout: "main",
        //extname: '.hbs',// le digo como va a ser la extencion de los archivos handlebars
        partialsDir: path.join(app.get("views"), "partials"),//le digo donde estan las vistas parciales y layouts
        layoutsDir: path.join(app.get("views"), "layouts"),
        helpers: require('./helpers'),
    });
    //app.engine('.hbs', exphbs.engine);
    //app.set('view engine', '.hbs');
    // Register `hbs.engine` with the Express app.
    app.engine('handlebars', hbs.engine);
    app.set('view engine', 'handlebars');

    //********* */
    //midelwares
    //********* */

    app.use(morgan('dev'));
    app.use(multer({dest: path.join(__dirname,'../public/upload/temp')}).single('image'))//se le indica single para que solo envie una imagen y se le puso el nombre image pero puede ser cualquier nombre (ej. file)
    app.use(express.urlencoded({extended:false}));//para poder recibir los datos que vengan de formularios
    app.use(express.json());//para poder usar ajax
    

    //********* */
    //routes
    //********* */

    routes(app);

    //********* */
    //static files 
    //********* */
    //Archivos que no cambian
    app.use('/public',express.static(path.join(__dirname,'../public')))

    //********* */
    //errorhandler
    //********* */
    if('development'=== app.get('env')){
        app.use(errorHandler);
    }


    return app;
}