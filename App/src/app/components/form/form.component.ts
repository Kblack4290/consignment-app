import { Component, OnInit } from '@angular/core';
import { NgForm, NgModel } from '@angular/forms';
import { DataService } from 'src/app/data/data.service';
import { FormSettings } from 'src/app/data/form-settings';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css'],
})
export class FormComponent implements OnInit {
  originalFormSettings: FormSettings = {
    FirstName: '',
    LastName: '',
    Email: '',
    Action: '',
    ItemName: '',
    Quantity: '',
    Category: '',
    Description: '',
  };

  formSettings: FormSettings = { ...this.originalFormSettings };
  postError = false;
  postErrorMessage = '';

  constructor(private dataService: DataService) {}

  ngOnInit(): void {}

  onBlur(field: NgModel) {
    console.log('in onBlur', field.valid);
  }

  onSubmit(form: NgForm) {
    console.log('Submitted works', form.valid);
    if (form.valid) {
      this.dataService.postFormSettings(this.formSettings).subscribe(
        (result) => console.log('success', result),
        (error) => this.onHttpError(error)
      );
    } else {
      this.postError = true;
      this.postErrorMessage = 'Please fix the above errors.';
    }
  }
  onHttpError(errorResponse: any) {
    console.log('error: ', errorResponse);
    this.postError = true;
    this.postErrorMessage = errorResponse.error.errorMessage;
  }
}
