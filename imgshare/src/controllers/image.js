const path = require('path');
const ctrl={};//controller
const utilidades = require('../helpers/libs');
const fs = require('fs-extra');
const md5 = require('md5');

//const Image = require('../models/image');
const {Image, Comment} = require('../models');//por defecto busca index '../models/index'

ctrl.index = async(req,res) => {
    //utilizo una exprecion regular para traer de la base la imagen que contiene uniqueId en su filename
    const image = await Image.findOne({ filename: {$regex: req.params.image_id} }).lean({ virtuals: true });
    //utilizar la funcion .lin() para poder usar handlebars en el html. Para que me retornara un objeto json no un documento mongoose.
    //la propiedad virtuals: true es para que lleguen las propiedad virtuales
    console.log(image);
    res.render('image',{image});
};

ctrl.create = (req,res) => {//se coloca async por que fs-extra funciona de forma ascincrona
    const saveImages= async ()=>{

        const imgURL = utilidades.randomNumber();
        const imgs = await Image.find({filename: imgURL});

        if(imgs.length>0){
            //Aplico recursion, no me gusta como estaa implementado, le habria puesto un id autogenerado a la BD
            saveImages(); //En caso que encuentre una imagen con el mismo nombre vuelve a ejecutar la funcion
        }else{
            const imageTempPath = req.file.path;//ruta de la imagen
            const ext = path.extname(req.file.originalname).toLowerCase();//con esto obtengo la extencion del archivo
            const targetPath= path.resolve('src/public/upload/'+ imgURL + ext);

            if(ext==='.jpg' ||ext==='.png' || ext==='.jpeg' || ext==='.gif'){

                await fs.rename(imageTempPath,targetPath);//mueve la imagen a la ruta targetPath, es ascincrona

                const newImg = new Image ({
                    title: req.body.title,
                    filename: imgURL + ext,
                    description: req.body.description,

                });

                const imgSave = await newImg.save(); // es ascincrono
                console.log(imgSave);
                res.redirect('/'); 
            }else{
                await fs.unlink(imageTempPath);//En caso que no cumpla con los formatos elimino la imagen de la carpeta tempdata
                res.status(500).json({error:'Solo imagenes esta permitido.'});
            }
        }
    }

    saveImages();
};
ctrl.like = (req,res) => {

};
ctrl.comment = async (req,res) => {
    const image = await Image.findOne({ filename: {$regex: req.params.image_id} }).lean({ virtuals: true });
    if(image){
        const newComment = new Comment(req.body);
        newComment.gravatar=md5(newComment.email);
        newComment.image_id=image._id;
        await newComment.save();
        console.log(newComment);
    }
    
    
    res.redirect('/images/'+image.uniqueId);
};
ctrl.remove = (req,res) => {

};

module.exports=ctrl;