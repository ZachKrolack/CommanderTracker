import { NgModule } from '@angular/core';
import { PageContainerComponent } from './page-container/page-container.component';
import { PageHeaderComponent } from './page-header/page-header.component';

@NgModule({
    imports: [PageContainerComponent, PageHeaderComponent],
    exports: [PageContainerComponent, PageHeaderComponent]
})
export class PageModule {}
