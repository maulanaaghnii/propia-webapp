'use client';

import '@/styles/globals.scss';
import { useEffect } from 'react';

export default function RootLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  useEffect(() => {
    require('@tabler/core/dist/js/tabler.min.js');
  }, []);

  return (
    <html lang="en">
      <body>
        <div className="page">
          <header className="navbar navbar-expand-md navbar-light d-print-none">
            <div className="container-xl">
              <h1 className="navbar-brand navbar-brand-autodark d-none-navbar-horizontal pe-0 pe-md-3">
                Population Dashboard
              </h1>
              <div className="navbar-nav flex-row order-md-last">
                <div className="nav-item">
                  <a href="/" className="nav-link px-0">
                    Home
                  </a>
                </div>
              </div>
            </div>
          </header>
          <div className="page-wrapper">
            <div className="container-xl">
              <div className="page-header d-print-none">
                <div className="row align-items-center">
                  <div className="col">
                    <div className="page-pretitle">Overview</div>
                    <h2 className="page-title">Population Dashboard</h2>
                  </div>
                </div>
              </div>
              {children}
            </div>
          </div>
        </div>
      </body>
    </html>
  );
}
