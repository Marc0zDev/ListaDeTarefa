import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TarefasCrudComponent } from './tarefas-crud.component';

describe('TarefasCrudComponent', () => {
  let component: TarefasCrudComponent;
  let fixture: ComponentFixture<TarefasCrudComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [TarefasCrudComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TarefasCrudComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
