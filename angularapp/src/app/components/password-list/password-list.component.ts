import { Component, OnInit, ViewChild } from '@angular/core';
import { PasswordService, PasswordEntry } from '../../services/password.service';
import { PasswordModalComponent } from "../password-modal/password-modal.component";

@Component({
  selector: 'app-root',
  templateUrl: './password-list.component.html',
  styleUrls: ['./password-list.component.css']
})
export class PasswordListComponent implements OnInit {
  @ViewChild(PasswordModalComponent) passwordModal!: PasswordModalComponent;
  passwords: PasswordEntry[] = [];
  isModalOpen = false;
  displayedColumns: string[] = ['name', 'password', 'date'];

  constructor(
    private passwordService: PasswordService
    ) { }

  ngOnInit(): void {
    this.loadPasswords();
  }

  loadPasswords(): void {
    this.passwordService.getPasswords().subscribe(response => {
      this.passwords = response.map(entry => ({ ...entry, isVisible: false }));
    });
  }

  onSearchTermChange(searchTerm: string): void {
    this.passwordService.getPasswords(searchTerm).subscribe(response => {
      this.passwords = response.map(entry => ({ ...entry, isVisible: false }));
    });
  }

  toggleVisibility(entry: PasswordEntry): void {
    entry.isVisible = !entry.isVisible;
  }

  get GetPasswords(): PasswordEntry[] {
    return this.passwords;
  }

  openModal(): void {
    this.passwordModal.openModal();
  }
}

