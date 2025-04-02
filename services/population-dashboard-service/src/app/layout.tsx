import '@tabler/core/dist/css/tabler.min.css';
import '@tabler/core/dist/js/tabler.min.js';

export const metadata = {
  title: 'Population Dashboard',
  description: 'Population Dashboard using Next.js and Tabler UI',
}

export default function RootLayout({
  children,
}: {
  children: React.ReactNode
}) {
  return (
    <html lang="en">
      <body>
        <div className="page">
          <header className="navbar navbar-expand-md navbar-light d-print-none">
            <div className="container-xl">
              <h1 className="navbar-brand navbar-brand-autodark d-none-navbar-horizontal pe-0 pe-md-3">
                Population Dashboard
              </h1>
            </div>
          </header>
          <div className="page-wrapper">
            {children}
          </div>
        </div>
      </body>
    </html>
  )
}
