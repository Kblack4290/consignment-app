import { Component, OnInit } from '@angular/core';
import { ItemsList } from './models/items';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-item-list',
  templateUrl: './item-list.component.html',
  styleUrls: ['./item-list.component.css'],
})
export class ItemListComponent implements OnInit {
  public itemsList: ItemsList[] = new Array<ItemsList>();

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.http
      .get<ItemsList[]>('https://localhost:7219/api/Consignment')
      .subscribe((data) => {
        this.itemsList = data;
      });
  }
}
