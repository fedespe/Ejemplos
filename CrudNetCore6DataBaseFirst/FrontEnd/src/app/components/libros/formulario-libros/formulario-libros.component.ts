import { Component, OnInit } from '@angular/core';
import {FormGroup, FormBuilder, Validators} from '@angular/forms';

@Component({
  selector: 'app-formulario-libros',
  templateUrl: './formulario-libros.component.html',
  styleUrls: ['./formulario-libros.component.css']
})
export class FormularioLibrosComponent implements OnInit {
  /*form: FormGroup ;*/

  constructor(private formbuilder:FormBuilder) { 
    /*this.form=this.formbuilder.group({
      id: 0,
      titulo: ["", [Validators.required]],
      descripcion: ["", [Validators.required]],
      fechaLanzamiento: ["", [Validators.required]],
      autor: ["", [Validators.required]],
      precio: [0, [Validators.required]],
    });*/
  }

  ngOnInit(): void {
  }

}
