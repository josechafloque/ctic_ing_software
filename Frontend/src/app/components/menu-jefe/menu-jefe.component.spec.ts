import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MenuJefeComponent } from './menu-jefe.component';

describe('MenuJefeComponent', () => {
  let component: MenuJefeComponent;
  let fixture: ComponentFixture<MenuJefeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MenuJefeComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MenuJefeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
