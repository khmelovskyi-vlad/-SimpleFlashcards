import { Injectable } from '@angular/core';
import { KeyValue } from '../../models/key-values/key-value';
import * as mainPath from '../../../assets/pathes/main-path.json';

@Injectable({
  providedIn: 'root'
})
export class UrlCreatorService {

  constructor() { }

  createUrl(parts: string[], params: KeyValue<string, string>[]): string{
    let url = '';
    for (let i = 0; i < parts.length; i++) {
      if (i == 0) {
        url += parts[i];
      }
      else {
        url += '/' + parts[i];
      }
    }
    if (params && params.length > 0) {
      url += '?';
      params.forEach(param => {
        url += param.key + '=' + param.value + '&';
      });
      url = url.substring(0, url.length - 1);
    }
    return url;
  }

  createMainApiUrl(parts: string[], params: KeyValue<string, string>[] = []): string{
    let url = mainPath.StartPath;
    url += '/';
    url += this.createUrl(parts, params);
    return url;
  }
}
