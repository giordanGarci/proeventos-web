import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { ChangeDetectionStrategy, ChangeDetectorRef, Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  standalone: true,
  templateUrl: './eventos.html',
  styleUrls: ['./eventos.scss'],
  imports: [CommonModule],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class EventosComponent implements OnInit {

  public eventos: any;

  constructor(private http: HttpClient, private cdr: ChangeDetectorRef) {}

  ngOnInit(): void {
    this.getEventos();
  }

  public getEventos(): void {
    this.http.get<any[]>('api/eventos').subscribe(
     {
      next: (response) => {
          this.eventos = response;
          this.cdr.markForCheck(); // Notifica o Angular para verificar mudanças
          console.log('Eventos carregados com sucesso', this.eventos);
      },
      error: error => {
        console.error('Erro ao carregar eventos', error);
      },
      complete: () => {
        console.log('Requisição de eventos concluída');
      }
     }
    )

  }
}
