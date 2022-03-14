import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatTable } from '@angular/material/table';
import {PeriodicElement} from 'src/app/models/PeriodicElement';
import { PeriodicElementService } from 'src/app/services/periodicElement.service';
import { ElementDialogComponent } from 'src/app/shared/element-dialog/element-dialog.component';


@Component({
  selector: 'app-person',
  templateUrl: './person.component.html',
  styleUrls: ['./person.component.css'],
  providers: [PeriodicElementService]
})
export class PersonComponent implements OnInit {

  @ViewChild(MatTable)
  table!: MatTable<any>
  displayedColumns: string[] = ['businessEntityID', 'phoneNumber', 'phoneNumberTypeID', 'actions'];
  dataSource !: PeriodicElement[];

  constructor(
    public dialog: MatDialog,
    public periodicElementService: PeriodicElementService) {
      this.periodicElementService.getElements()
      .subscribe((data: PeriodicElement[]) => {
        this.dataSource = data;
      })
    }

  ngOnInit(): void {
  }

  openDialog(element: PeriodicElement | null): void{
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
        this.periodicElementService.editElement(result)
        .subscribe((data: PeriodicElement) =>{
          this.dataSource[result.businessEntityID] = result
        })
      }else{
        this.periodicElementService.createElements(result)
        .subscribe((data: PeriodicElement) =>{
          this.dataSource.push(result);
          this.table.renderRows();
        })
        
      }
    }
  });

  }
  deleteElement(businessEntityID: number, phoneNumber: string, phoneNumberTypeID: number): void{
    this.periodicElementService.deleteElement(businessEntityID, phoneNumber, phoneNumberTypeID)
    .subscribe(() => {
      this.dataSource = this.dataSource.filter(p => p.businessEntityID !== businessEntityID);
    })
    
  }
  editElement(element: PeriodicElement): void{
    this.openDialog(element)
  }

}
