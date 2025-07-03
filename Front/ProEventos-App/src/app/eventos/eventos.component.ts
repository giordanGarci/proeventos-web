import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { ChangeDetectionStrategy, ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { CollapseModule } from 'ngx-bootstrap/collapse';


@Component({
  selector: 'app-eventos',
  standalone: true,
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss'],
  imports: [CommonModule, CollapseModule, FormsModule],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class EventosComponent implements OnInit {

  public eventos: any = [];
  public filteredEventos: any = this.eventos;
  marginImg: number = 2;
  widthImg: number = 150;
  showImg: boolean = true;
  private _listFilter: string = '';

  public get listFilter(): string {
    return this._listFilter;
  }
  public set listFilter(value: string) {
    this._listFilter = value;
    this.filteredEventos = this.listFilter ? this.filterEventos(this.listFilter) : this.eventos;
  }

  private filterEventos(filterBy: string): any[] {
    filterBy = filterBy.toLocaleLowerCase();
    return this.eventos.filter(
      (evento: any) => evento.tema.toLocaleLowerCase().includes(filterBy) ||
      evento.local.toLocaleLowerCase().includes(filterBy)
    );
  }

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
          this.filteredEventos = this.eventos; // Inicializa o filtro com todos os eventos
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

  public toggleImg(): void {
    this.showImg = !this.showImg;
    this.cdr.markForCheck();
    console.log('Exibir Imagem:', this.showImg);
  }

}
