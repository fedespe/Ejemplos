const express = require('express');
const router = express.Router();
//importo controladores para MVC
const home = require('../controllers/home');
const image = require('../controllers/image');
module.exports = app => {

    // app.get('/',(req,res) => {
    //     res.send('Index page');
    // })
    router.get('/',home.index);
    router.get('/images/:image_id',image.index);
    router.post('/images',image.create);
    router.post('/images/:image_id/like',image.like);
    router.post('/images/:image_id/comment',image.comment);
    router.delete('/images/:image_id',image.remove);

    
    app.use(router);

};