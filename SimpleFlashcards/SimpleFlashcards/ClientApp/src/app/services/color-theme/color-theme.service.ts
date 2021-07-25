import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { ColorTheme } from '../../value-objects/color-theme';

@Injectable({
  providedIn: 'root'
})
export class ColorThemeService {

  selectedColorTheme = new BehaviorSubject(this.colorTheme);
  constructor() { }
  
  set colorTheme(value: ColorTheme) {
    localStorage.setItem('colorTheme', JSON.stringify(value));
    this.selectedColorTheme.next(value);
  }
 
  get basketGoods(): ColorTheme {
    const json = localStorage.getItem('colorTheme');
    if (json != undefined) {
      return JSON.parse(json) as ColorTheme;
    }
    else{
      ColorTheme.white;
    }
  }
}
