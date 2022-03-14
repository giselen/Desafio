import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatTable } from '@angular/material/table';
import {ElementPerson} from 'src/app/models/ElementPerson';
import { ElementPersonService } from 'src/app/services/ElementPerson.service';
import { ElementDialogComponent } from 'src/app/shared/element-dialog/element-dialog.component';


@Component({
  selector: 'app-person',
  templateUrl: './person.component.html',
  styleUrls: ['./person.component.css'],
  providers: [ElementPersonService]
})
export class PersonComponent implements OnInit {

  @ViewChild(MatTable)
  table!: MatTable<any>
  displayedColumns: string[] = ['businessEntityID', 'phoneNumber', 'phoneNumberTypeID', 'actions'];
  dataSource !: ElementPerson[];

  constructor(
    public dialog: MatDialog,
    public ElementPersonService: ElementPersonService) {
      this.ElementPersonService.getElements()
      .subscribe((data: ElementPerson[]) => {
        this.dataSource = data;
      })
    }

  ngOnInit(): void {
  }

  openDialog(element: ElementPerson | null): void{
    const dialogRef = this .dialog.open(ElementDialogComponent, {
      width : '250px' ,
      data : element === null? {
        businessEntityID: null,
        phoneNumber: '',
        phoneNumberTypeID:null
      }: {
        businessEntityID: element.businessEntityID,
        phoneNumber: element.phoneNumber,
        phoneNumberTypeID:element.phoneNumberTypeID
      }
   });

   dialogRef.afterClosed().subscribe(result => {
    if(result !== undefined){
      if(this.dataSource.map(p => p.businessEntityID).includes(result.businessEntityID)){
        this.ElementPersonService.editElement(result)
        .subscribe((data: ElementPerson) =>{
          this.dataSource[result.businessEntityID] = result
        })
      }else{
        this.ElementPersonService.createElements(result)
        .subscribe((data: ElementPerson) =>{
          this.dataSource.push(result);
          this.table.renderRows();
        })
        
      }
    }
  });

  }
  deleteElement(businessEntityID: number, phoneNumber: string, phoneNumberTypeID: number): void{
    this.ElementPersonService.deleteElement(businessEntityID, phoneNumber, phoneNumberTypeID)
    .subscribe(() => {
      this.dataSource = this.dataSource.filter(p => p.businessEntityID !== businessEntityID);
    })
    
  }
  editElement(element: ElementPerson): void{
    this.openDialog(element)
  }

}
