# -*- mode: ruby -*-
# vi: set ft=ruby :

Vagrant.configure("2") do |config|
        # Node R1 configuration
	config.vm.define "hosta" do |hosta|
		hosta.vm.box = "srouting/srv6-net-prog"
		hosta.vm.box_version = "0.4.14"
		hosta.vm.synced_folder(".", nil, :disabled => true, :id => "vagrant-root")
		hosta.vm.network "private_network", ip: "10.0.0.1", libvirt__intnet: "netv4a"
		hosta.vm.provider "libvirt" do |v|
			v.memory = "256"
		end
                hosta.vm.hostname = "hosta"
		hosta.vm.provision "shell", path: "config/config_a.sh"
        end
        
	config.vm.define "hostb" do |hostb|
		hostb.vm.box = "srouting/srv6-net-prog"
		hostb.vm.box_version = "0.4.14"
		hostb.vm.synced_folder(".", nil, :disabled => true, :id => "vagrant-root")
		hostb.vm.network "private_network", ip: "10.0.1.1", libvirt__intnet: "netv4b"
		hostb.vm.provider "libvirt" do |v|
			v.memory = "256"
		end
                hostb.vm.hostname = "hostb"
		hostb.vm.provision "shell", path: "config/config_b.sh"
        end
        
	# Node R1 configuration
	config.vm.define "r1" do |r1|
		r1.vm.box = "srouting/srv6-net-prog"
		r1.vm.box_version = "0.4.14"
		r1.vm.synced_folder(".", nil, :disabled => true, :id => "vagrant-root")
		r1.vm.network "private_network", ip: "10.0.0.2", libvirt__intnet: "netv4a"
		r1.vm.network "private_network",
                  libvirt__ipv6_address: "2001:12::1",
                  libvirt__dhcp_enabled: false,
                  libvirt__guest_ipv6: "yes",
                  libvirt__network_name: "net12",
                  libvirt__ipv6_prefix: "64",
                  libvirt__forward_mode: "route"

		r1.vm.provider "libvirt" do |libvirt|
			libvirt.memory = "256"

		end
                r1.vm.hostname = "r1"
		r1.vm.provision "shell", path: "config/config_r1.sh"
	end

	# Node R2 configuration
	config.vm.define "r2" do |r2|
		r2.vm.box = "srouting/srv6-net-prog"
		r2.vm.box_version = "0.4.14"
                r2.vm.synced_folder(".", nil, :disabled => true, :id => "vagrant-root")
		r2.vm.network "private_network",
                  libvirt__ipv6_address: "2001:12::2",
                  libvirt__dhcp_enabled: false,
                  libvirt__guest_ipv6: "yes",
                  libvirt__network_name: "net12",
                  libvirt__ipv6_prefix: "64",
                  libvirt__forward_mode: "route"
		r2.vm.network "private_network",
                  libvirt__ipv6_address: "2001:23::1",
                  libvirt__dhcp_enabled: false,
                  libvirt__guest_ipv6: "yes",
                  libvirt__network_name: "net23",
                  libvirt__ipv6_prefix: "64",
                  libvirt__forward_mode: "route"
		r2.vm.network "private_network",
                  libvirt__ipv6_address: "2001:a::1",
                  libvirt__dhcp_enabled: false,
                  libvirt__guest_ipv6: "yes",
                  libvirt__network_name: "netserver1",
                  libvirt__ipv6_prefix: "64",
                  libvirt__forward_mode: "route"

		r2.vm.provider "libvirt" do |libvirt|
			libvirt.memory = "256"
			libvirt.cpus = "1"
		end
                r2.vm.hostname = "r2"
		r2.vm.provision "shell", path: "config/config_r2.sh"
	end

        # Node R3 configuration
        config.vm.define "r3" do |r3|
                r3.vm.box = "srouting/srv6-net-prog"
                r3.vm.box_version = "0.4.14"
		r3.vm.synced_folder(".", nil, :disabled => true, :id => "vagrant-root")
		r3.vm.network "private_network", ip: "10.0.1.2", libvirt__intnet: "netv4b"
		r3.vm.network "private_network",
                  libvirt__ipv6_address: "2001:23::2",
                  libvirt__dhcp_enabled: false,
                  libvirt__guest_ipv6: "yes",
                  libvirt__network_name: "net23",
                  libvirt__ipv6_prefix: "64",
                  libvirt__forward_mode: "route"
		r3.vm.network "private_network",
                  libvirt__ipv6_address: "2001:b::1",
                  libvirt__dhcp_enabled: false,
                  libvirt__guest_ipv6: "yes",
                  libvirt__network_name: "netserver2",
                  libvirt__ipv6_prefix: "64",
                  libvirt__forward_mode: "route"
                r3.vm.provider "libvirt" do |libvirt|
			libvirt.memory = "256"

                end
                r3.vm.hostname = "r3"
	        r3.vm.provision "shell", path: "config/config_r3.sh"
        end
        # server1 configuration
        config.vm.define "server1" do |server1|
                server1.vm.box = "srouting/srv6-net-prog"
                server1.vm.box_version = "0.4.14"
                server1.vm.synced_folder(".", nil, :disabled => true, :id => "vagrant-root")
		server1.vm.network "private_network",
                  libvirt__ipv6_address: "2001:a::2",
                  libvirt__dhcp_enabled: false,
                  libvirt__guest_ipv6: "yes",
                  libvirt__network_name: "netserver1",
                  libvirt__ipv6_prefix: "64",
                  libvirt__forward_mode: "route"
                server1.vm.provider "libvirt" do |libvirt|
			libvirt.memory = "256"
                end
                server1.vm.hostname = "server1"
		server1.vm.provision "shell", path: "config/config_server1.sh"
        end

        # server2 configuration
        config.vm.define "server2" do |server2|
                server2.vm.box = "srouting/srv6-net-prog"
                server2.vm.box_version = "0.4.14"
                server2.vm.synced_folder(".", nil, :disabled => true, :id => "vagrant-root")
		server2.vm.network "private_network",
                  libvirt__ipv6_address: "2001:b::2",
                  libvirt__dhcp_enabled: false,
                  libvirt__guest_ipv6: "yes",
                  libvirt__network_name: "netserver2",
                  libvirt__ipv6_prefix: "64",
                  libvirt__forward_mode: "route"
                server2.vm.provider "libvirt" do |libvirt|
			libvirt.memory = "256"
                end
                server2.vm.hostname = "server2"
	        server2.vm.provision "shell", path: "config/config_server2.sh"
        end
end
