import {Component, EventEmitter, Output, ViewChild} from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PasswordService, PasswordEntry } from '../../services/password.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-password-modal',
  templateUrl: './password-modal.component.html',
  styleUrls: ['./password-modal.component.css']
})
export class PasswordModalComponent {
  @Output() refresh = new EventEmitter<void>();

  passwordForm: FormGroup;
  showModal = false;

  constructor(
    private fb: FormBuilder,
    private passwordService: PasswordService,
    private snackBar: MatSnackBar
    ) {
    this.passwordForm = this.fb.group({
      name: ['', Validators.required],
      password: ['', [Validators.required, Validators.minLength(8)]],
      type: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    this.passwordForm.get('type')!.valueChanges.subscribe(selectedType => {
      const nameControl = this.passwordForm.get('name');
      if (selectedType === 'Website') {
        nameControl!.setValidators([Validators.required]);
      } else if (selectedType === 'Email') {
        nameControl!.setValidators([Validators.required, Validators.email]);
      }
      nameControl!.updateValueAndValidity();
    });
  }

  openModal(): void {
    this.showModal = true;
  }

  closeModal(): void {
    this.showModal = false;
    this.passwordForm.reset({ type: 'Website' });
  }

  savePassword(): void {
    if (this.passwordForm.valid) {
      const newEntry: PasswordEntry = {
        id: 0,
        ...this.passwordForm.value
      };

      this.passwordService.addPassword(newEntry).subscribe(
        () => {
          this.closeModal();
          this.refresh.emit();
        },
        error => {
          this.snackBar.open('Ошибка при сохранении пароля. Возможно данный ресурс уже добавлен.', 'Закрыть', {
            duration: 3000,
            panelClass: ['custom-snackbar'],
            horizontalPosition: 'center',
            verticalPosition: 'top'
          });
        }
      );
    }
  }
}
