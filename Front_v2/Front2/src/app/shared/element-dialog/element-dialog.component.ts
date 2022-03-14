import {Component, Inject, OnInit} from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { ElementPerson } from 'src/app/models/ElementPerson';

@Component({
  selector: 'app-element-dialog',
  templateUrl: './element-dialog.component.html',
  styleUrls: ['./element-dialog.component.css']
})
export class ElementDialogComponent implements OnInit {
  element!: ElementPerson;
  isChange !: boolean;

  constructor(
    @Inject(MAT_DIALOG_DATA) 
    public data: ElementPerson,
    public dialogRef: MatDialogRef<ElementDialogComponent>,  
  ) {}

  ngOnInit(): void {
    if(this.data.businessEntityID != null){
      this.isChange = true
    }else{
      this.isChange = false
    }
  }

  onCancel(): void {
    this.dialogRef.close();
  }

}
