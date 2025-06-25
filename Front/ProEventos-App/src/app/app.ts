import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { EventosComponent } from "./eventos/eventos.component";
import { Palestrantes } from "./palestrantes/palestrantes.component";


@Component({
  selector: 'app-root',
  imports: [RouterOutlet, EventosComponent, Palestrantes],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
  protected title = 'ProEventos-App';
}
