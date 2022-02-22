const ctrl={};//controller
const {Image} = require('../models');//trabaja con ../models/index

ctrl.index = async(req,res) => {
    const images = await Image.find().sort({timestamp:-1}).lean({ virtuals: true });//si queremos ordenar de manera ascendente se coloca 1, -1 para descendente
    //utilizar la funcion .lin() para poder usar handlebars en el html. Para que me retornara un objeto json no un documento mongoose.
    //la propiedad virtuals: true es para que lleguen las propiedad virtuales
    //console.log(JSON.stringify(images));
    res.render('index',{images});//En versiones anteriores de js res.render('index',{images: images});
};

module.exports=ctrl;