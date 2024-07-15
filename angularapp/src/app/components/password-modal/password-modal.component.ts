import { Component, EventEmitter, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PasswordService, PasswordEntry } from '../../services/password.service';

@Component({
  selector: 'app-password-modal',
  templateUrl: './password-modal.component.html',
  styleUrls: ['./password-modal.component.css']
})
export class PasswordModalComponent {
  @Output() refresh = new EventEmitter<void>();

  passwordForm: FormGroup;
  showModal = false;

  constructor(private fb: FormBuilder, private passwordService: PasswordService) {
    this.passwordForm = this.fb.group({
      name: ['', Validators.required],
      password: ['', [Validators.required, Validators.minLength(8)]],
      type: ['site', Validators.required]
    });
  }

  closeModal(): void {
    this.showModal = false;
    this.passwordForm.reset({ type: 'site' });
  }

  savePassword(): void {
    if (this.passwordForm.valid) {
      const newEntry: PasswordEntry = {
        id: 0,  // Здесь можно задать ID как угодно, например, автоинкремент на сервере
        ...this.passwordForm.value,
        date: new Date()
      };

      this.passwordService.addPassword(newEntry).subscribe(() => {
        this.closeModal();
        this.refresh.emit();
      });
    }
  }
}
