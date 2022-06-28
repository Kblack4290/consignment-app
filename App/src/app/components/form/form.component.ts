import { Component, OnInit } from '@angular/core';
import { FormSettings } from 'src/app/data/form-settings';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css'],
})
export class FormComponent implements OnInit {
  originalFormSettings: FormSettings = {
    firstName: 'Keith',
    lastName: 'Black',
    email: 'keithblack4290@gmail.com',
    action: 'Sell',
    itemName: 'Toy Car',
    quantity: '1',
    category: 'Toys',
    description: 'Pretty cool car. I have had since I was a wee lad',
  };

  formSettings: FormSettings = { ...this.originalFormSettings };
  constructor() {}

  ngOnInit(): void {}
}
