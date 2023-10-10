import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteroomComponent } from './deleteroom.component';

describe('DeleteroomComponent', () => {
  let component: DeleteroomComponent;
  let fixture: ComponentFixture<DeleteroomComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DeleteroomComponent]
    });
    fixture = TestBed.createComponent(DeleteroomComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
