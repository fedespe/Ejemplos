const mongoose = require('mongoose');
const {Schema} = mongoose;
const {ObjectId}=Schema;//para relacionar las tablas, los mismo serio const ObjectId = Schema.ObjectId;
const path = require('path');
const mongooseLeanVirtuals = require('mongoose-lean-virtuals');

const opts = { toJSON: { virtuals: true } };
const commentSchema = mongoose.Schema({
    image_id: {type : ObjectId }, //Para decirle que es clave de otra tabla, es del tipo _id que usa mongo
    name: {type : String },
    email: {type : String },
    gravatar: {type : String },//atributo para usar servicio gravatar, es para ver la imagen de perfil que pusiste en gravatar
    comment: {type : String },
    timestamp: {type: Date, default: Date.now}
}, opts);

module.exports = mongoose.model('Comment',commentSchema);