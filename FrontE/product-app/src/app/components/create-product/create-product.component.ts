import { Component } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { Product } from '../../models/product';
import { ProductService } from '../../services/product.service';
import { FormsModule } from '@angular/forms';

@Component({
    selector: 'app-create-product',
    templateUrl: './create-product.component.html',
    styleUrls: ['./create-product.component.css'],
    standalone: true,
    imports: [FormsModule, RouterLink]
})
export class CreateProductComponent {
  product: Product = {
    name: '',
    description: '',
    price: 0
  };

  constructor(
    private productService: ProductService,
    private router: Router
  ) { }

  onSubmit(): void {
    if (this.product.name && this.product.price) {
      this.productService.createProduct(this.product).subscribe({
        next: () => this.router.navigate(['/products']),
        error: (err) => alert('Failed to create product. Make sure API is running.')
      });
    }
  }
}
